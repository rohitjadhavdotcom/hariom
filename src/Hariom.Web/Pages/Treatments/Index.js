$(function () {
    let l = abp.localization.getResource('Hariom');

    let createModal = new abp.ModalManager(abp.appPath + 'Treatments/CreateModal');
    let editModal = new abp.ModalManager(abp.appPath + 'Treatments/EditModal');

    let dataTable = $('#TreatmentsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: false,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(hariom.treatments.treatment.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Hariom.Treatments.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Hariom.Treatments.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l('TreatmentDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        hariom.treatments.treatment
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }

                            ]
                    }
                },
                {
                    title: l('Disease Name'),
                    data: "diseaseName"
                },
                {
                    title: l('About Disease'),
                    data: "aboutDisease"
                },
                {
                    title: l('Disease Symptoms'),
                    data: "diseaseSymptoms"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );


    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });


    $('#NewTreatmentButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
