function Country() {

        $('#country').empty();
        $('#country').append($('<option>', {value: 'select', text: '--Select--' }));

        $.ajax({
            type: "GET",
            url: "/User/CountryDataList",
            dataType: "json",
            success: function (Result) {
                var items = '';
                $.each(Result, function (Result, items) {
                $("#country").append($("<option></option>").val
                (items.countryName).html(items.countryName));

                });
        State();
            },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("Not Found");
            }
        });
}
function State() {
        var e = document.getElementById("country");
        var strUser = e.options[e.selectedIndex].value;
        $('#state').empty();
        $('#state').append($('<option>', {value: 'select', text: '--Select--' }));
            $.ajax({
                type: "GET",
            url: "/User/StateDataList",
            data: {val: strUser },
            dataType: "json",
            success: function (Result) {
                var items = ''
            $.each(Result, function (Result, items) {
                $("#state").append($("<option></option>").val
                    (items.stateName).html(items.stateName));

                });
            City();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log("Not Found");
            }
        });
}
function City() {
        var e = document.getElementById("state");
            var strUser = e.options[e.selectedIndex].value;
            $('#city').empty();
            $('#city').append($('<option>', {value: 'select', text: '--Select--' }));
                $.ajax({
                    type: "GET",
                url: "/User/CityDataList",
                data: {val: strUser },
                dataType: "json",
                success: function (Result) {
                var items = ''
                $.each(Result, function (Result, items) {
                    $("#city").append($("<option></option>").val
                        (items.cityName).html(items.cityName));
                });
            },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log("Not Found");
            }
        });
}
function email_validate() {
        var email = document.getElementById("email").value;
                var formData = new FormData();

                formData.append("email_valid", email);

                $.ajax({
                    type: "POST",
                url: "/User/EmailValidate",
                data: formData,
                processData: false,
                contentType: false,
                dataType: "json",
                success: function (Result) {

                if (Result == "Found") {
                    alert("Email Already Exist");
                $("#submit").prop("disabled", true);
                }
                else{
                    $("#submit").prop("disabled", false);
                }
            },
                error: function (Result) {
                    console.log(Result.data);
            }
        });

}
function ShowPass() {
    var x = document.getElementById("password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
function RegisterSubmitUser() {

    var firstName = document.getElementById("firstname").value;
    var lastName = document.getElementById("lastname").value;
    var user_email = document.getElementById("email").value;
    var e1 = document.getElementById("country");
    var user_country = e1.options[e1.selectedIndex].value;
    var e1 = document.getElementById("state");
    var user_state = e1.options[e1.selectedIndex].value;
    var e1 = document.getElementById("city");
    var user_city = e1.options[e1.selectedIndex].value;
    var user_phone = document.getElementById("phone").value;
    var user_password = document.getElementById("password").value;
    var fileInput = document.getElementById('myFile');
    var file = fileInput.files[0];

    var formData = new FormData();
    var form = $('#__AjaxAntiForgeryForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    formData.append('FirstName', firstName);
    formData.append('LastName', lastName);
    formData.append('Email', user_email);
    formData.append('Country', user_country);
    formData.append('State', user_state);
    formData.append('City', user_city);
    formData.append('Phone', user_phone);
    formData.append('Password', user_password);
    formData.append('Image', file);
    formData.append('__RequestVerificationToken', token);//adding antiforgergery token

    $.ajax({
        type: "POST",
        url: "/User/AddUser",
        data: formData,
        processData: false,
        contentType: false,
        dataType: "json",
        success: function (Result) {

            if (Result == "Success") {
                alert("Data Submitted Successfully")
                window.location.href = '@Url.Action("ShowData", "User")'
            }
            else {
                alert("Data is not submitted");
            }
        },
        error: function (Result) {
            console.log(Result.data);
        }
    });
}
var addFunctionOnWindowLoad = function (callback) {

        if (window.addEventListener) {
                    window.addEventListener('load', callback, false);
        }
        else {
                    window.attachEvent('onload', callback);
        }
    }

addFunctionOnWindowLoad(Country);

