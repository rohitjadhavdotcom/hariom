$(function () {
    let l = abp.localization.getResource('Hariom');

    let createModal = new abp.ModalManager(abp.appPath + 'Diseases/CreateModal');
    let editModal = new abp.ModalManager(abp.appPath + 'Diseases/EditModal');

    let dataTable = $('#DiseasesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: false,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(hariom.diseases.disease.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Hariom.Diseases.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Hariom.Diseases.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l('DiseaseDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        hariom.diseases.disease
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
                    title: l('Name'),
                    data: "name"
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


    $('#NewDiseaseButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
