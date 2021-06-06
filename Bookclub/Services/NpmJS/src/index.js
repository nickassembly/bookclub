// test with infragistics js library radial gauge component
import { ModuleManager } from 'igniteui-webcomponents-core';
import { IgcRadialGaugeCoreModule } from 'igniteui-webcomponents-gauges';
import { IgcRadialGaugeModule } from 'igniteui-webcomponents-gauges';

ModuleManager.register(
    IgcRadialGaugeCoreModule,
    IgcRadialGaugeModule
);

window.updateValue = function (value) {
    var rg = document.getElementById("rg");
    rg.value = value;
}