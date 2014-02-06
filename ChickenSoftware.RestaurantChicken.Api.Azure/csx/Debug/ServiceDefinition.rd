<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="ChickenSoftware.RestaurantChicken.Api.Azure" generation="1" functional="0" release="0" Id="6554e8a1-5f48-4c62-941a-cbeed5f9562d" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="ChickenSoftware.RestaurantChicken.Api.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="ChickenSoftware.RestaurantChicken.Api:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/LB:ChickenSoftware.RestaurantChicken.Api:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="ChickenSoftware.RestaurantChicken.Api:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/MapChickenSoftware.RestaurantChicken.Api:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="ChickenSoftware.RestaurantChicken.ApiInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/MapChickenSoftware.RestaurantChicken.ApiInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:ChickenSoftware.RestaurantChicken.Api:Endpoint1">
          <toPorts>
            <inPortMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/ChickenSoftware.RestaurantChicken.Api/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapChickenSoftware.RestaurantChicken.Api:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/ChickenSoftware.RestaurantChicken.Api/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapChickenSoftware.RestaurantChicken.ApiInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/ChickenSoftware.RestaurantChicken.ApiInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="ChickenSoftware.RestaurantChicken.Api" generation="1" functional="0" release="0" software="C:\Git\ChickenSoftware.RestraurantChicken.Solution\ChickenSoftware.RestaurantChicken.Api.Azure\csx\Debug\roles\ChickenSoftware.RestaurantChicken.Api" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;ChickenSoftware.RestaurantChicken.Api&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;ChickenSoftware.RestaurantChicken.Api&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/ChickenSoftware.RestaurantChicken.ApiInstances" />
            <sCSPolicyUpdateDomainMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/ChickenSoftware.RestaurantChicken.ApiUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/ChickenSoftware.RestaurantChicken.ApiFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="ChickenSoftware.RestaurantChicken.ApiUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="ChickenSoftware.RestaurantChicken.ApiFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="ChickenSoftware.RestaurantChicken.ApiInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="5e705c29-20d8-417d-9974-2cd618b50ef0" ref="Microsoft.RedDog.Contract\ServiceContract\ChickenSoftware.RestaurantChicken.Api.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="1a2852e5-95b7-4a4a-b656-c42fea61d499" ref="Microsoft.RedDog.Contract\Interface\ChickenSoftware.RestaurantChicken.Api:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/ChickenSoftware.RestaurantChicken.Api.Azure/ChickenSoftware.RestaurantChicken.Api.AzureGroup/ChickenSoftware.RestaurantChicken.Api:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>