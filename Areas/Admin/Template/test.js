﻿
jQuery(function () {

    jQuery("#test").on("click",
        ".btnTest",
        function () {
            bootbox.confirm({
                message: "This is a confirm with custom button text and color! Do you like it?",
                buttons: {
                    confirm: {
                        label: 'Yes',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'No',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    console.log('This was logged in the callback: ' + result);
                }
            });

        });
});