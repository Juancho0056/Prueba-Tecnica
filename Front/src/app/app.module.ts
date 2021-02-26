import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { SideNavOuterToolbarModule, SideNavInnerToolbarModule, SingleCardModule } from './layouts';
import { FooterModule, LoginFormModule } from './shared/components';
import { AuthService, ScreenService, AppInfoService, AuthGuardService } from './shared/services';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { Util } from './config/Util';
import { DxCheckBoxModule, DxNumberBoxModule, DxFormModule, DxSelectBoxModule, DxDataGridModule, DxTextAreaModule, DxLoadPanelModule } from 'devextreme-angular';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IgxAvatarModule } from 'igniteui-angular';
import { ArticuloModule } from './pages/articulo/articulo.module';
import { FacturaModule } from './pages/factura/factura.module';
import { ClienteModule } from './pages/cliente/cliente.module';
import { ArticuloService } from './pages/articulo/service/articulo.service';
import { ClienteService } from './pages/cliente/service/cliente.service';
import { UnidadService } from './pages/articulo/service/unidad.service';
import { FacturaService } from './pages/factura/service/factura.service';
import dxLoadPanel from 'devextreme/ui/load_panel';
import { DxoFilterRowModule, DxoHeaderFilterModule, DxoSearchPanelModule } from 'devextreme-angular/ui/nested';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    SideNavOuterToolbarModule,
    SideNavInnerToolbarModule,
    SingleCardModule,
    FooterModule,
    LoginFormModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    DxCheckBoxModule,
    DxSelectBoxModule,
    DxNumberBoxModule,
    DxFormModule,
    DxDataGridModule,
    DxCheckBoxModule,
    DxTextAreaModule,
    IgxAvatarModule,
    BrowserAnimationsModule,
    DxLoadPanelModule,
    DxoFilterRowModule,
    DxoHeaderFilterModule,
    DxoSearchPanelModule
  ],
  providers: [
    AuthService,
    ScreenService,
    AppInfoService,
    Util,
    ArticuloService,
    ClienteService,
    UnidadService,
    FacturaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
platformBrowserDynamic().bootstrapModule(AppModule);
