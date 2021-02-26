import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from 'src/app/shared/services';
import { DevExtremeModule, DxDataGridModule, DxFormModule } from 'devextreme-angular';
import { ArticuloComponent } from './articulo.component';
import { DxoLoadPanelModule } from 'devextreme-angular/ui/nested';

const routes: Routes = [
  
  {
    path: 'list',
    component: ArticuloComponent,
    canActivate: [ AuthGuardService]
  }
];

@NgModule({
  declarations: [ArticuloComponent],
  imports: [
    CommonModule, RouterModule.forChild(routes),DxDataGridModule, DxFormModule, DxoLoadPanelModule, DevExtremeModule
  ]
})
export class ArticuloModule { }
