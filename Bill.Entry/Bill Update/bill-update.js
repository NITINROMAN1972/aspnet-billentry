

$(document).ready(function () {

    // search bill no
    $('#ddScBillNo').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });


    // search vendor
    $('#ddScVendor').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // search unit
    $('#ddScUnit').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // search imprest card no
    $('#ddScImpstCardNo').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });







    // vendor
    $('#ddVendor').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // unit / office
    $('#ddUnitOffice').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // imprest card no
    $('#ddImprestCardNo').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });
    $('#ddImprestCardNo').on('select2:select', function (e) {
        __doPostBack('ddImprestCardNo', '');
    });

    // imprest card holder
    $('#ddImprestCardHolder').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // allocate head
    $('#ddAlloctHead').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });



    // item
    $('#ddItem').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });

    // uom
    $('#ddUOM').select2({
        theme: 'classic',
        placeholder: 'Select here.....',
        allowClear: false,
    });





    // Reinitialize Select2 after UpdatePanel partial postback
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    // Reinitialize Select2 for all dropdowns
    prm.add_endRequest(function () {

        setTimeout(function () {

            // search bill no
            $('#ddScBillNo').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // search vendor
            $('#ddScVendor').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // search unit
            $('#ddScUnit').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // search imprest card no
            $('#ddScImpstCardNo').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });






            // vendor
            $('#ddVendor').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // unit / office
            $('#ddUnitOffice').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // imprest card no
            $('#ddImprestCardNo').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });
            $('#ddImprestCardNo').on('select2:select', function (e) {
                __doPostBack('<%= ddImprestCardNo.ClientID %>', '');
            });

            // imprest card holder
            $('#ddImprestCardHolder').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // allocate head
            $('#ddAlloctHead').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });




            // item
            $('#ddItem').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

            // uom
            $('#ddUOM').select2({
                theme: 'classic',
                placeholder: 'Select here.....',
                allowClear: false,
            });

        }, 0);
    });

});