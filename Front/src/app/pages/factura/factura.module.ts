import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FacturaComponent } from './factura.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from 'src/app/shared/services';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';
import { DxFormModule, DxNumberBoxModule, DxSelectBoxModule, DxCheckBoxModule, DxDataGridModule, DevExtremeModule } from 'devextreme-angular';

const routes: Routes = [
  {
    path: 'list',
    component: FacturaComponent,
    canActivate: [ AuthGuardService]
  }
];

@NgModule({
  declarations: [FacturaComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    DxDataGridModule, 
    DxFormModule,
    DxSelectBoxModule,
    DxNumberBoxModule,
    DxCheckBoxModule,
    DevExtremeModule
  ]
})
export class FacturaModule { }
