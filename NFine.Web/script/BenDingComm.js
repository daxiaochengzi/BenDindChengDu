var iniActiveX=null;
var baseInfo = {
    HospitalInfo: {
        "Account": null,//账户
        "Pwd": null,  // 密码
        "OperatorId": null,   //操作人员
        "InsuranceType": null, // 险种类型,
        "IdentityMark": null,    //身份标志   身份证号或个人编号
        "AfferentSign": null,// 传入标志 1为公民身份号码 2为个人编号,
        "CardPwd": null //卡密码
    },
    Inpatient: {
        "PersonalCoding": null ,//个人编码
        "PatientName": null,  // 病人姓名
        "PatientSex": null,   //性别
        "Birthday": null,    //出生日期
        "InsuranceType": null, // 险种类型,
        "IdCardNo": null ,// 身份证,
        "AccountBalance": null,//账户余额
        "MedicalInsuranceSign": null,//医保标识
        "InsuranceName": null//医保标识
       
    }
};
//判断插件是否存在
function DetectActiveX() {
    try {
       
        if (iniActiveX === null) {
            iniActiveX= document.getElementById("CSharpActiveX");
        }
        var versionNumber = iniActiveX.name;
        var activeVersionNumber = iniActiveX.GetVersionNumber();
        if (parseInt(versionNumber) > parseInt(activeVersionNumber)) {
            msgError("当前插件版本过低,请下载新的版本!!!");
        }//签到检查
        else {
            
            SignInCheck();
        }

    }
    catch (e) {
        msgError("请检查当前医保插件是否安装,IE浏览器插件功能是否打开!!!");
        return false;
    }
    return true;
}
//签到检查
function SignInCheck() {
    var operatorId = iniJs("#empid").val();
   
    var activeData = iniActiveX.YiHaiOutpatientMethods("GetSignInUserId", "GetSignInUserId"
        , "GetSignInUserId", operatorId);
   
    var activeJsonData = JSON.parse(activeData);
    if (activeJsonData.Success === true) {
        if (activeJsonData.Data !== "" || activeJsonData.Data !== null) {
            //非同一操作员重新初始化
            if (activeJsonData.Data !== operatorId) {
                medicalInsuranceSignIn();
            }
        } else
        {
            medicalInsuranceSignIn();
        }
       
    }
}
//医保签到
function medicalInsuranceSignIn() {
    var queryParam = {
        "UserId": iniJs("#empid").val() /*授权操作人的ID*/
    }

    iniJs.ajax({
        type: 'post',
        url: hostNew + '/GetMedicalInsuranceSignInParam',
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
                        , "MedicalInsuranceSignIn", iniJs("#empid").val());
                    var activeJsonData = JSON.parse(activeData);
                    if (activeJsonData.Success === false) {
                        msgError(activeJsonData.Message);
                     

                    } else {
                        //取消签到数据存入数据库
                        //queryParam["ResultJson"] = activeJsonData.Data;
                        //YiHaiMedicalInsuranceSignIn(queryParam);
                    }
                }


            }
        }

    });
}

////签到
//function medicalInsuranceSignIn(signInParam) {
//    iniJs.ajax({
//        type: 'post',
//        url: hostNew + '/MedicalInsuranceSignIn',
//        data: signInParam,
//        dataType: "json",
//        async: false,
//        success: function (data) {

//            if (data.Success === false) {
//                var errData = data.Message;
//                msgError(errData);
//                //样式类名:墨绿深蓝风
//            } 
//        }

//    });
//}

//按钮状态
function buttonStatus(buttonId, status) {
    //取消禁用
    if (status === true) {
        iniJs("#" + buttonId).attr("class", "layui-btn layui-btn-radius");
        iniJs("#" + buttonId).removeAttr("disabled");
    }//禁用
    else {
        iniJs("#" + buttonId).attr("class", "layui-btn layui-btn-disabled layui-btn-radius");
        iniJs("#" + buttonId).attr("disabled", 'disabled');
    }
}
//医保取消交易
function medicalInsuranceCancelTransaction(serialNumber) {
    var activeData = iniActiveX.YiHaiOutpatientMethods(serialNumber, serialNumber
        , "CancelDeal", iniJs("#empid").val());
    var activeJsonData = JSON.parse(activeData);
    if (activeJsonData.Success === false) {
        msgError(activeJsonData.Message);
        
    }
}
//获取结算返回值
function settlementData(data) {
   
    var html = "";
    for (var i in data) {
        if (data.hasOwnProperty(i)) {

            html += '<div class="layui-inline">';
            html += '     <label class="layui-form-label">' + data[i].Name + '</label>';
            html += '     <div class="layui-input-inline">';
            html += '     <input type="text" name="AdmissionDiagnosticDoctor" autocomplete="off"   value="' + data[i].Value + '" disabled class="layui-input layui-disabled">';
            html += '     </div>';
            html += '</div>';
        }
    }
    if (html !== "") {
        iniJs("#SettleData").empty();
        iniJs("#SettleData").append(html);
    }

}
//获取患者基本信息
function getInpatientInfo(getInpatientInfoBack) {
   
      var activeX = document.getElementById("CSharpActiveX");
    var activeData = activeX.YiHaiOutpatientMethods("", "","GetUserInfo","");
        var activeJsonData = JSON.parse(activeData);
        if (activeJsonData.Success === false) {
            msgError(activeJsonData.Message);
        } else {
         
            //病人信息赋值
            var activeJsonInfo = JSON.parse(activeJsonData.Data);
            baseInfo.Inpatient["PersonalCoding"] = activeJsonInfo.PersonalCoding;
            baseInfo.Inpatient["PatientName"] = activeJsonInfo.PatientName;
            baseInfo.Inpatient["PatientSex"] = activeJsonInfo.PatientSex;
            baseInfo.Inpatient["Birthday"] = activeJsonInfo.Birthday;
            baseInfo.Inpatient["InsuranceType"] = activeJsonInfo.InsuranceType;
            baseInfo.Inpatient["IdCardNo"] = activeJsonInfo.IdCardNo;
            baseInfo.Inpatient["AccountBalance"] = activeJsonInfo.AccountBalance;
            baseInfo.Inpatient["MedicalInsuranceSign"] = activeJsonInfo.MedicalInsuranceSign;
            baseInfo.Inpatient["InsuranceName"] = activeJsonInfo.InsuranceName;
            baseInfo.HospitalInfo.AfferentSign = "2";
            baseInfo.HospitalInfo.IdentityMark = activeJsonInfo.PersonalCoding;
            getInpatientInfoBack();
        }
}
//读卡获取患者基本信息
function getReadCardInpatientInfo(getInpatientInfoBack) {

    var cardPwd = baseInfo.HospitalInfo.CardPwd;
  
    if (cardPwd === "" || cardPwd === null) {
        msgError("密码不能为空!!!");
    }
    var activeX = document.getElementById("CSharpActiveX");
    var activeData = activeX.OutpatientMethods(cardPwd, JSON.stringify(baseInfo.HospitalInfo), "ReadCardUserInfo");
    var activeJsonData = JSON.parse(activeData);
    if (activeJsonData.Success === false) {
        msgError(activeJsonData.Message);
    } else {
        //病人信息赋值
        var activeJsonInfo = JSON.parse(activeJsonData.Data);
        baseInfo.Inpatient["PersonalCoding"] = activeJsonInfo.PersonalCoding;
        baseInfo.Inpatient["PatientName"] = activeJsonInfo.PatientName;
        baseInfo.Inpatient["PatientSex"] = activeJsonInfo.PatientSex;
        baseInfo.Inpatient["Birthday"] = activeJsonInfo.Birthday;
        baseInfo.Inpatient["InsuranceType"] = activeJsonInfo.InsuranceType;
        baseInfo.Inpatient["IdCardNo"] = activeJsonInfo.IdCardNo;
        baseInfo.Inpatient["ResidentInsuranceBalance"] = activeJsonInfo.ResidentInsuranceBalance;
        baseInfo.Inpatient["WorkersInsuranceBalance"] = activeJsonInfo.WorkersInsuranceBalance;
        baseInfo.HospitalInfo.AfferentSign = "2";
        baseInfo.HospitalInfo.IdentityMark = activeJsonInfo.PersonalCoding;
        getInpatientInfoBack();
    }
}
function msgSuccess(successData) {
    iniMsg.alert(successData, { icon: 6, shade: 0.1, skin: 'layui-layer-molv', title: '温馨提示' });
}
function msgError(errData) {
    iniMsg.alert(errData, { skin: 'layui-layer-molv', icon: 5, title: '错误提示' });
}
