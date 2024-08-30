$(function () {
    let l = abp.localization.getResource('Hariom');

    let createModal = new abp.ModalManager(abp.appPath + 'YogTherapies/CreateModal');
    let editModal = new abp.ModalManager(abp.appPath + 'YogTherapies/EditModal');

    let dataTable = $('#YogTherapiesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: false,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(hariom.yogTherapies.yogTherapy.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Hariom.YogTherapies.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Hariom.YogTherapies.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l('YogTherapyDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        hariom.yogTherapies.yogTherapy
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
                    title: l('YogopcharCategory'),
                    data: "yogopcharCategory"
                },
                {
                    title: l('YogopcharTherapy'),
                    data: "yogopcharTherapy"
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


    $('#NewYogTherapyButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
