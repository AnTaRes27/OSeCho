using Newtonsoft.Json;
using System.Security.Cryptography;
using VRChat.API.Model;
using VRCOSC.App.SDK.Modules;
using VRCOSC.App.SDK.Parameters;
using VRCOSC.App.SDK.Parameters.Queryable;
using VRCOSC.App.Utils;
using Windows.Management.Deployment;



namespace antares27.osecho
{
    [ModuleTitle("OSC Echo")]
    [ModuleDescription("Echoes received OSC Messages to another parameter")]
    [ModuleType(ModuleType.Generic)]
    public class EchoModule : Module
    {
        protected override void OnPreLoad()
        {
            //CreateToggle(EchoModuleSetting.ToggleSetting, "Toggle Title", "Toggle Description", false);
            //CreateState(EchoParamState.Default, "Default");
            CreateCustomSetting(EchoParamsSetting.EchoParams, new EchoModuleSetting());
            CreateState(EchoModuleState.Default, "Default");
            CreateGroup("Echoed Parameters", EchoParamsSetting.EchoParams);
        }

        //protected override void OnPostLoad()
        //{
        //    var moduleSetting = GetSetting<EchoModuleSetting>(EchoParamsSetting.EchoParams)!;
        //    moduleSetting.Attribute.OnCollectionChanged(echoparam)
        //}

        //private void echoParamsCollectionChanged(IEnumerable<EchoParam> newItems, IEnumerable<EchoParam> oldItems)
        //{
        //    foreach (EchoParam newEchoParam in newItems)
        //    {
                
        //    }
        //}

        protected override async Task<bool> OnModuleStart()
        {
            ChangeState(EchoModuleState.Default);
            //var echoParams = GetSettingValue<List<EchoParam>>(EchoParamsSetting.EchoParams);

            //foreach (var echoParam in echoParams)
            //{
            //    foreach (ActionableQueryableParameter<EchoParamAction> queryableParameter in echoParam.InputParameter)
            //    {
            //        await queryableParameter.Init();
            //    }
            //}

            return true;
        }

        protected override async void OnAnyParameterReceived(ReceivedParameter receivedParameter)
        {
            var echoParams = GetSettingValue<List<EchoParam>>(EchoParamsSetting.EchoParams);

            foreach (var echoParam in echoParams)
            {
                if (receivedParameter.Name.Equals(echoParam.InputParameter))
                {
                    SendParameter(echoParam.OutputParameter.Value, receivedParameter.Value);
                }
                //foreach (ActionableQueryableParameter<EchoParamAction> queryableParameter in echoParam.InputParameter)
                //{
                //    if (receivedParameter.Name == queryableParameter.Name.Value)
                //    {
                //        SendParameter(echoParam)
                //    }
                    
                //}
            }
        }


        private enum EchoParamsSetting
        {
            EchoParams
        }

        private enum EchoModuleState
        {
            Default
        }
    }
}
