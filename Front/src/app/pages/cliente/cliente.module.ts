import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from 'src/app/shared/services';
import { DxFormModule, DxNumberBoxModule, DxSelectBoxModule, DxCheckBoxModule, DxDataGridModule, DevExtremeModule } from 'devextreme-angular';
import { BrowserModule } from '@angular/platform-browser';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';
import { ClienteComponent } from './cliente.component';

const routes: Routes = [
  {
    path: 'list',
    component: ClienteComponent,
    canActivate: [ AuthGuardService]
  }
];

@NgModule({
  declarations: [ClienteComponent],
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
export class ClienteModule { }
