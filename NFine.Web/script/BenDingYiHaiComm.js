//判断插件是否存在
var YiHaiAPI = "/api/YiHai";
function DetectActiveX() {
    try {
        var activeX = document.getElementById("CSharpActiveX");
        var versionNumber = activeX.name;
        var activeVersionNumber = activeX.GetVersionNumber();
        if (parseInt(versionNumber) > parseInt(activeVersionNumber)) {
            $.modalAlert("当前插件版本过低,请下载新的版本!!!", "error");
        }
    }
    catch (e) {
        $.modalAlert("请检查医保插件是否安装,是否使用IE浏览器打开!!!!!!", "error");
    }
 
}

//签到检查
function YiHaiSignInCheck() {
   
    var queryParam = {
        "UserId": $("#empid").val() /*授权操作人的ID*/
    }
    $.ajax({
        type: 'post',
        url: YiHaiAPI + '/GetMedicalInsuranceSignInParam',
        data: queryParam,
        dataType: "json",
        async: false,
        success: function (data) {

            if (data.Success === false) {
                var errData = data.Message;
                $.modalAlert(errData, "error");
            
                //样式类名:墨绿深蓝风
            } else {
                var dataValue = data.Data;
                if (dataValue.TransactionInputXml !== null) {
                    var activeX = document.getElementById("CSharpActiveX");
                  
                    var activeData = activeX.YiHaiOutpatientMethods(dataValue.TransactionControlXml, dataValue.TransactionInputXml
                        , "MedicalInsuranceSignIn", $("#empid").val());
                    var activeJsonData = JSON.parse(activeData);
                    if (activeJsonData.Success === false) {
                        $.modalAlert(activeJsonData.Message, "error");
                       
                    } else {
                        queryParam["ResultJson"] = activeJsonData.Data;
                        YiHaiMedicalInsuranceSignIn(queryParam);
                    }
                }


            }
        }

    });
}

function YiHaiMedicalInsuranceSignIn(signInParam) {
    $.ajax({
        type: 'post',
        url: YiHaiAPI + '/MedicalInsuranceSignIn',
        data: signInParam,
        dataType: "json",
        async: false,
        success: function (data) {

            if (data.Success === false) {
                var errData = data.Message;
                $.modalAlert(errData, "error");
              
                //样式类名:墨绿深蓝风
            }
        }

    });
}

