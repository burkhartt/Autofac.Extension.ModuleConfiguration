Autofac.Extension.ModuleConfiguration
=====================================
Tired of using Autofac modules like this:

```
var appSetting1 = ConfigurationManager.AppSettings["appSetting1"];
var appSetting2 = ConfigurationManager.AppSettings["appSetting2"];
var appSetting3 = ConfigurationManager.AppSettings["appSetting3"];
var appSetting4 = ConfigurationManager.AppSettings["appSetting4"];
var appSetting5 = ConfigurationManager.AppSettings["appSetting5"];
var appSetting6 = ConfigurationManager.AppSettings["appSetting6"];

var myModule = new MyModule(appSetting1, appSetting2, appSetting3, appSetting4, appSetting5, appSetting6);

container.RegisterModule(myModule);

```

And tired of your web.config/app.config looking like this:

```
<appSettings>
   <add key="MyModuleEndpoint" value="MyValue" />
   <add key="OtherModuleEndpoint" value="MyValue" />
</appSettings>
```

Autofac.Extension.ModuleConfiguration allows you to do it this way:

```
<configSections>
   <section name="autofacModules" type="Autofac.Extension.ModuleConfiguration.ModulesSection, Autofac.Extension.ModuleConfiguration" />
</configSections>
```

```
<autofacModules>
   <modules>
      <module name="EmailMarketing">
         <properties>
            <property name="endpoint" value="myEndpoint" />
         </properties>
      </module>
      <module name="Sales">
         <properties>
            <property name="endpoint" value="salesEndpoint" />
         </properties>
      </module>
   </modules>
</autofacModules>
```

It also supports referencing connectionStrings and appSettings:

```
<appSettings>
   <add key="myAppSetting" value="myValue" />
</appSettingS>

<connectionStrings>
   <add name="myConn" connectionString="..." />
</connectionStrings>

<autofacModules>
   <modules>
      <module name="EmailMarketing">
         <properties>
            <property name="endpoint" appSetting="myAppSetting" />
            <property name="conn" connectionString="myConn" />
         </properties>
      </module>
   </modules>
</autofacModules>
```

All you have to do is extend ConfigurableModule (extends Autofac Module class)

```
public class MyModule : ConfigurableModule {

}
```
