$(function () {
    let l = abp.localization.getResource('Hariom');

    let createModal = new abp.ModalManager(abp.appPath + 'Medicines/CreateModal');
    let editModal = new abp.ModalManager(abp.appPath + 'Medicines/EditModal');

    let dataTable = $('#MedicinesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(hariom.medicines.medicine.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Hariom.Medicines.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Hariom.Medicines.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l('MedicineDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        hariom.medicines.medicine
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


    $('#NewMedicineButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
