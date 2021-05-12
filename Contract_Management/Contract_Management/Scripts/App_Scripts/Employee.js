function CopyAddress() {
    if ($("#SameAsPermanent").is(":checked") === true) {
        $("#PERMANENT_ADRS").val($("#PRESENT_ADRS").val());
    }
    else {
        $("#PERMANENT_ADRS").val("");
    }

}
function Cancel() {
    window.location.href = "../Home/Index";
}




$(document).ready(function () {
    var status = getUrlVars()["status"];
    if (status == "Error") {
        $.notify("Warning: Please fill all requred fields", "error");
        if (window.location.href.indexOf('?') > -1) {
            history.pushState('', document.title, window.location.pathname);
        }
    }
    else if (status == "Saved") {
        $.notify("Info: Employee Details Saved Successfully", "success");
        if (window.location.href.indexOf('?') > -1) {
            history.pushState('', document.title, window.location.pathname);
        }
    }
    else if (status == "Updated") {
        $.notify("Info: Employee Details Updated Successfully", "success");
        if (window.location.href.indexOf('?') > -1) {
            history.pushState('', document.title, window.location.pathname);
        }
    }


    if ($("#EMP_ID").val() != null) {
        debugger
        BindDocuments();
    }

    //$("#MARITAL_STATUS").select2('data', { id: 1, text: 'MARRIED' }).trigger('change');
    $(".nav,li").removeClass('active');
    $("#employee").addClass('active');
    $("#ESI_REGN_DATE").datepicker({
        dateFormat: "dd/mm/yy"
    });
    $("#PF_REGN_DATE").datepicker({
        dateFormat: "dd/mm/yy"
    });
    //$("#ESI_REGN_DATE").datepicker({ dateFormat: 'dd/MM/yyyy' });
    //$("#PF_REGN_DATE").datepicker({ format: 'dd/MM/yyyy' });
    $("#DOB").datepicker({ format: 'dd/MM/yyyy' });
    $("#DOJ").datepicker({ format: 'dd/MM/yyyy' });
    $("#BLACK_LISTED_DATE").datepicker({ format: 'dd/MM/yyyy' });
    $("#WC_POLICY_VALID_UPTO").datepicker({ format: 'dd/MM/yyyy' });
    $("#PO_NUM").select2({
        placeholder: 'Select PO Number',
        allowClear: true,
        minimumInputLength: 0,
        ajax: {

            url: "../Contractor/GetAllPOs/",
            dataType: 'json',
            quietMillis: 250,
            type: "POST",
            data: function (term, page, type) {
                return {
                    q: term, //search term
                    page: page, // page number
                    type: type,
                };
            },
            results: function (data, page) {
                debugger
                data = JSON.parse(data);
                var more = (page * 30) < data.total_count;
                return { results: data.items, more: more };
            }
        }
    });


    $("#ESIExemption").select2({
        placeholder: 'ESI Exemption',
        allowClear: true,
        minimumInputLength: 0,
        ajax: {
            url: "../Contractor/GetESIExemptionSelect2/",
            dataType: 'json',
            quietMillis: 250,
            type: "POST",
            data: function (term, page, type) {
                return {
                    q: term, //search term
                    page: page, // page number
                    type: type,
                };
            },
            results: function (data, page) {
                data = JSON.parse(data);
                var more = (page * 30) < data.total_count;
                return { results: data.items, more: more };
            }
        }
    });

    $('#employeeform').validate({ // initialize the plugin
        ignore: [],
        rules: {
            PO_NUM: {
                required: true
            },
            EMP_NAME: {
                required: true
            },
            MARITAL_STATUS: {
                required: true,
            },
            DOB: {
                required: true,
                dateITA: true
            },
            NO_WORKERS: {
                required: true,
                digits: true
            },
            RELATION_IP: {
                required: true,
            },
            RELATION_NAME: {
                required: true,
            },
            District: {
                required: true,
            },
            STATE: {
                required: true,
            },
            PERMANENT_ADRS: {
                required: true,
            },
            PINCODE: {
                required: true,
                digits: true,
                minlength: 6,
                maxlength: 6
            },
            ICE_PHONE: {
                required: true,
            },
            ESIExemption: {
                required: true,
            },
            PF_EXEMPTION: {
                required: true,
            },
            ID_TYPE: {
                required: true,
            },
            ID_NUM: {
                required: true,
                digits: true,
                minlength: 12,
                maxlength: 12
            },
            BANK_NAME: {
                required: true,
            },
            BANK_BRANCH: {
                required: true,
            },
            BANK_ACNO: {
                required: true,
                digits: true
            },
            BANK_IFSC: {
                required: true,
            },
            EMP_PF_NO: {
                required: function () {
                    return $("#PFExemption").val() == "1";
                }
            },
            PF_REGN_DATE: {
                required: function () {
                    return $("#PFExemption").val() == "1";
                },
                dateITA: function () {
                    return $("#PFExemption").val() == "1";
                }
            },
            UAN: {
                required: function () {
                    return $("#PFExemption").val() == "1";
                }
            },
            EMPR_PF_CODE: {
                required: function () {
                    return $("#PFExemption").val() == "1";
                }
            },
            WCPolicy: {
                required: function () {
                    return $("#ESIExemption").val() == "2";
                }
            },
            WC_POLICY_VALID_UPTO: {
                required: function () {
                    return $("#ESIExemption").val() == "2";
                },
                dateITA: function () {
                    return $("#ESIExemption").val() == "2";
                }
            },
            EMP_ESINO: {
                required: function () {
                    return $("#ESIExemption").val() == "1";
                }
            },
            ESI_REGN_DATE: {
                required: function () {
                    return $("#ESIExemption").val() == "1";
                },
                dateITA: function () {
                    return $("#ESIExemption").val() == "1";
                }
            },
            EMPR_ESI_CODE: {
                required: function () {
                    return $("#ESIExemption").val() == "1";
                }
            },
        }
    });

    $("#RELATION_IP").select2({
        placeholder: 'Relationship',
        allowClear: true,
        minimumInputLength: 0,
        ajax: {
            url: "../Contractor/GetEmployee_RelationsSelect2/",
            dataType: 'json',
            quietMillis: 250,
            type: "POST",
            data: function (term, page, type) {
                return {
                    q: term, //search term
                    page: page, // page number
                    type: type,
                };
            },
            results: function (data, page) {
                data = JSON.parse(data);
                var more = (page * 30) < data.total_count;
                return { results: data.items, more: more };
            }
        }
    });
    $("#MARITAL_STATUS").select2({
        placeholder: 'Marital Status',
        allowClear: true,
        minimumInputLength: 0,
        ajax: {
            url: "../Contractor/GetEmployee_MaritalStatusSelect2/",
            dataType: 'json',
            quietMillis: 250,
            type: "POST",
            data: function (term, page, type) {
                return {
                    q: term, //search term
                    page: page, // page number
                    type: type,
                };
            },
            results: function (data, page) {
                data = JSON.parse(data);
                var more = (page * 30) < data.total_count;
                return { results: data.items, more: more };
            }
        }
    });
    $("#EMP_TYPE").select2({
        placeholder: 'Marital Status',
        allowClear: true,
        minimumInputLength: 0,
        ajax: {
            url: "../Contractor/GetEmployee_TypeSelect2/",
            dataType: 'json',
            quietMillis: 250,
            type: "POST",
            data: function (term, page, type) {
                return {
                    q: term, //search term
                    page: page, // page number
                    type: type,
                };
            },
            results: function (data, page) {
                data = JSON.parse(data);
                var more = (page * 30) < data.total_count;
                return { results: data.items, more: more };
            }
        }
    });
    $("#PFExemption").select2({
        placeholder: 'PF Exemption',
        allowClear: true,
        minimumInputLength: 0,
        ajax: {
            url: "../Contractor/GetPFExemptionSelect2/",
            dataType: 'json',
            quietMillis: 250,
            type: "POST",
            data: function (term, page, type) {
                return {
                    q: term, //search term
                    page: page, // page number
                    type: type,
                };
            },
            results: function (data, page) {
                data = JSON.parse(data);
                var more = (page * 30) < data.total_count;
                return { results: data.items, more: more };
            }
        }


    });

    $('#ESIExemption').on("change", function (e) {
        if ($('#ESIExemption').val() == 2) {
            $("#div_WC_Policy").prop('disabled', false);
            $("#div_ESI").prop('disabled', true);
            $('#div_ESI').find('input:text').each(function () {
                $(this).val('');
            });
        }
        else if ($('#ESIExemption').val() == 1) {
            $("#div_WC_Policy").prop('disabled', true);
            $("#div_ESI").prop('disabled', false);
            $('#div_WC_Policy').find('input:text').each(function () {
                $(this).val('');
            });
        }
    });
    $('#ESIExemption').on('select2-removed', function (e) {
        $("#div_WC_Policy").prop('disabled', true);
        $("#div_ESI").prop('disabled', true);
        $("#WCPolicy").val("");
        $("#WC_POLICY_VALID_UPTO").val("");
        $("#ESI_NO").val("");
        $("#ESI_REGN_DATE").val("");
        $("#EMPR_ESI_CODE").val("");
    });

    $('#PFExemption').on("change", function (e) {
        if ($('#PFExemption').val() == 1) {
            $("#div_PF").prop("disabled", false);
            
        }
        else if ($('#PFExemption').val() == 2) {
            $("#div_PF").prop("disabled", true);
            $('#div_PF').find('input:text').each(function () {
                $(this).val('');
            });
        }
    });
    $('#PFExemption').on('select2-removed', function (e) {
        $("#UAN").attr("disabled", true);
        $("#EMP_PF_NO").attr("disabled", true);
        $("#PF_REGN_DATE").attr("disabled", false);
        $("#EMPR_PF_CODE").attr("disabled", true);
        $("#UAN").val("");
        $("#EMP_PF_NO").val("");
        $("#EMPR_PF_CODE").val("");
    });


    if ($("#hd_MARITAL_STATUS").val() != null) {
        var MARITAL_STATUS = $("#hd_MARITAL_STATUS").val().split('_');
        $("#MARITAL_STATUS").select2('data', { id: MARITAL_STATUS[0], text: MARITAL_STATUS[1] }).trigger('change');
    }
    if ($("#hd_PO_NUM").val() != null) {
        var text = $("#hd_PO_NUM").val();
        $("#PO_NUM").select2('data', { id: text, text: text }).trigger('change');
    }
    if ($("#hd_RELATION_IP").val() != null) {
        var RELATION = $("#hd_RELATION_IP").val().split('_');
        $("#RELATION_IP").select2('data', { id: RELATION[0], text: RELATION[1] }).trigger('change');
    }
    if ($("#hd_ESIExemption").val() != null) {        
        var ESIExemption = $("#hd_ESIExemption").val().split('_');
        $("#ESIExemption").select2('data', { id: ESIExemption[0], text: ESIExemption[1] }).trigger('change');
        //if(ESIExemption[0]==1)
        //{
        //    debugger
        //    $("#div_WC_Policy").prop("disabled", true);
        //    $("#div_ESI").prop("disabled", false);
        //}
        //else
        //{
        //    $("#div_WC_Policy").prop("disabled", false);
        //    $("#div_ESI").prop("disabled", true);
        //}
    }
    if ($("#hd_EMP_TYPE").val() != null) {
        var EMP_TYPE = $("#hd_EMP_TYPE").val().split('_');
        $("#EMP_TYPE").select2('data', { id: EMP_TYPE[0], text: EMP_TYPE[1] }).trigger('change');
    }
    if ($("#hd_PF_EXEMPTION").val() != null) {
        var PFExemption = $("#hd_PF_EXEMPTION").val().split('_');
        $("#PFExemption").select2('data', { id: PFExemption[0], text: PFExemption[1] }).trigger('change');
        if (PFExemption[0] == 1) {
            debugger
            //$("#div_WC_Policy").prop("disabled", true);
            $("#div_PF").prop("disabled", false);
        }
        else {
            //$("#div_WC_Policy").prop("disabled", false);
            $("#div_PF").prop("disabled", true);
            
        }
    }
   


});









function show(input) {//For Photo Preview
    debugger
    if (input.files && input.files[0]) {
        var filerdr = new FileReader();
        filerdr.onload = function (e) {
            $('#user_img').attr('src', e.target.result);
        }
        filerdr.readAsDataURL(input.files[0]);
    }
}
var dept = [];
var POs = [];

function GetAllDepartments() {
    debugger
    var vendorno = $("#vendorcode").val();
    var url = "../Contractor/GetAllDepartments";
    var data = { q: "", page: 1, type: "" }
    if ($("#vendorcode").val() != "") {
        $.post(url, data, function (result) {
            debugger
            console.log(result.Content)
            if (result.length > 0) {
                var list = $.parseJSON(result)
                dept = list.items
                $("#department").select2({ data: dept });
            }
            else {
                $("#vendorcode").notify("Vendor Not Registered", { position: "left" }, "warn");
            }


        });
    }
    else {
        $("#vendorcode").addClass("error");
    }
}

function GetAllPOs() {
    debugger
    var vendorno = $("#vendorcode").val();
    var url = "../Contractor/GetAllPOs";
    var data = { q: "", page: 1, type: "" }
    if ($("#vendorcode").val() != "") {
        $.post(url, data, function (result) {
            debugger
            console.log(result.Content)
            if (result.length > 0) {
                var list = $.parseJSON(result)
                POs = list.items
                $("#PO_NUM").select2({ data: POs });
            }
            else {

            }

        });
    }
    else {
        $("#vendorcode").addClass("error");
    }


}


function GetJobByJobId(job_id) {
    debugger
    //var url = "Contractor/GetJobByJobId";
    //var data = { job_id: job_id }
    //$.post(url, data, function (result) {

    //});

    var vendorno = $("#vendorcode").val();
    var url = "../Contractor/GetJobByJobId";
    var data = { job_id: job_id }
    if ($("#vendorcode").val() != "") {
        $.post(url, data, function (result) {
            debugger
            console.log(result.Content)
            if (result.length > 0) {
                var list = $.parseJSON(result)
                POs = list.items
                $("#JOB_ID").select2({ data: POs });
            }
            else {
                $("#vendorcode").notify("Vendor Not Registered", { position: "left" }, "warn");
            }


        });
    }
    else {
        $("#vendorcode").addClass("error");
    }
}

function BindDocuments() {
    debugger
    var EMP_ID = $("#EMP_ID").val();
    var url = "../Contractor/GetAllEMPDOCSByEMPID";
    var data = { EMP_ID: EMP_ID }
    $.post(url, data, function (result) {
        debugger
        if ((JSON.parse(result).success) == true) {
            result = JSON.parse(result).results;
            for (var i = 0; i < result.length; i++) {
                var transid = result[i]["TRANS_ID"] + "_" + result[i]["DOC_ID"];
                $("#img_table").append("<tr id='tr_" + result[i]["TRANS_ID"] + "'>" +
                  "<th>" + result[i]["DOC_NAME"] + "</th>" +
                  "<td><button type='button' onclick='DeleteImg(\"" + transid + "\")'>Delete</button></td>)" +
                  "<td><button type='button' onclick='GetUploadedImg(\"" + transid + "\")' data-fancybox data-src='#hidden-content' href='javascript:;'>Preview</button></td></tr>");

                var vals = result[i]["DOC_ID"];
                var SELECTED_DOCS = $("#SELECTED_DOCS").val();
                SELECTED_DOCS = SELECTED_DOCS + "," + result[i]["DOC_ID"];
                $("#SELECTED_DOCS").val(SELECTED_DOCS);

                $("#DOC_TYPE").select2("val", "");
                //  BindDOC_TYPE_Select2();
                $("#uploadedFile").val("");
                $("#uploadedFile").attr("disabled", true);

            }

        }


    });


}

//function GetAllDepartmentSelect2() {
//    debugger
//    $("#department").select2({
//        // allowClear: true,
//        placeholder: 'Search options...',
//        minimumInputLength: 0,
//        ajax: {
//            url: '@(Url.Action("GetAllDepartments", "Contractor"))',//"~/Contractor/GetAllDepartments",
//            dataType: 'jsonp',
//            quietMillis: 250,
//            data: function (term, page, type) {
//                alert("hai");
//                return {
//                    q: term, //search term
//                    page: page, // page number
//                    type: type,


//                };
//            },
//            results: function (data, page) {
//                data = JSON.parse(data);
//                var more = (page * 30) < data.total_count;
//                return { results: data.items, more: more };
//            }
//        }
//    });
//}


function ResetForm() {
    $("#btnReset").trigger("click");
    $("#DEPT_ID").select2('destroy');
    Bind_DEPT_ID();
    $("#div_ARC").prop('disabled', true);
    $("#div_ISMW").prop('disabled', false);
    EnableLisence();
    $("#div_ISMW").prop('disabled', true);
    //var validator = $("#employeeform").validate();
    //validator.resetForm();
}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

