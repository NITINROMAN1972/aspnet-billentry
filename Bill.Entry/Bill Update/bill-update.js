

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








    $('#gridSearch').DataTable({
        //scrollY: "420px",
        scrollX: false,
        scrollCollapse: false,
        paging: true,
        searching: true,
        ordering: true,
        info: true,
        lengthChange: true,
        responsive: true,
        pagingType: 'full_numbers',

        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, 'All']
        ],

        search: {
            return: false
        },
        initComplete: function () {
            $('.dataTables_filter input').attr('placeholder', ' search here......')
                .before('<span class="search-icon"><img src="/img/icons/search.svg" alt="Search Icon" style="height: 1em; width: auto;" /></span>');
        },

        language: {
            search: "",
            decimal: ',',
            thousands: '.'
        },
    });

    $(function () {
        $("[id*=itemGrid]").DataTable(
            {
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });
    });


 /* $(function () {
        $("[id*=itemGrid]").DataTable(
            {
                bLengthChange: true,
                lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                bFilter: true,
                bSort: true,
                bPaginate: true
            });*/
    
});
