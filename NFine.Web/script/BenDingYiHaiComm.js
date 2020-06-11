//判断插件是否存在
var YiHaiAPI = "/api/YiHai";
var yiHaiActiveX = null;
function DetectActiveX() {
    try {
        yiHaiActiveX = document.getElementById("CSharpActiveX");
        var versionNumber = yiHaiActiveX.name;
        var activeVersionNumber = yiHaiActiveX.GetVersionNumber();
        if (parseInt(versionNumber) > parseInt(activeVersionNumber)) {
            $.modalAlert("当前插件版本过低,请下载新的版本!!!", "error");
        } else {
            YiHaiSignInCheck();
        }
    }
    catch (e) {
        $.modalAlert("请检查医保插件是否安装,是否使用IE浏览器打开!!!!!!", "error");
    }
 
}

//签到检查
function YiHaiSignInCheck() {
   
 
        var operatorId = $("#empid").val();



        var activeData = iniActiveX.YiHaiOutpatientMethods("GetSignInUserId", "GetSignInUserId"
            , "GetSignInUserId", operatorId);

        var activeJsonData = JSON.parse(activeData);
        if (activeJsonData.Success === true) {
            if (activeJsonData.Data !== "" || activeJsonData.Data !== null) {
                //非同一操作员重新初始化
                if (activeJsonData.Data !== operatorId) {
                    getMedicalInsuranceSignInParam();
                }
            } else {
                getMedicalInsuranceSignInParam();
            }

        }

}
function getMedicalInsuranceSignInParam() {
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
                msgError(errData);
                //样式类名:墨绿深蓝风
            } else {

                var dataValue = data.Data;
                if (dataValue.TransactionInputXml !== null) {

                    var activeData = iniActiveX.YiHaiOutpatientMethods(dataValue.TransactionControlXml, dataValue.TransactionInputXml
                        , "MedicalInsuranceSignIn", $("#empid").val());
                    var activeJsonData = JSON.parse(activeData);
                    if (activeJsonData.Success === false) {
                        $.modalAlert(activeJsonData.Message, "error");

                    } 
                    
                }


            }
        }

    });
}