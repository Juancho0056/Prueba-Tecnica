import { Component, OnInit, NgModule, enableProdMode, ViewChild, AfterViewInit } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';
import { ArticuloService } from './service/articulo.service';
import { Articulo } from './model/Articulo';
import { Existencia } from './model/Existencia';
import { IUnidad } from './model/IUnidad';
import { UnidadService } from './service/unidad.service';
import { retry } from 'rxjs/operators';
import {Item} from '../../config/Item';
@Component({
  selector: 'app-articulo',
  templateUrl: './articulo.component.html',
  styleUrls: ['./articulo.component.scss']
})
export class ArticuloComponent implements OnInit, AfterViewInit {

  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;
  showHeaderFilter: boolean = true;
  showFilterRow: boolean = true;
  allMode: string;
  checkBoxesMode: string;
  loadingVisible = true;
  articulos:  Existencia[] = [];
  unidades:  Item[] = [];
  unidadesText: string[] = [];
  constructor(private articuloService: ArticuloService, private unidadService : UnidadService) {
    this.allMode = 'allPages';
    this.checkBoxesMode = 'onClick';
    
  }

  ngAfterViewInit() {
  }
  ngOnInit() {
    this.GetAllArticulo();
    this.GetAllUnidades();
  }
  onValueChanged (e) {
  }

  GetAllUnidades() {
    this.unidadService.GetAll().pipe(
      retry(1)).subscribe((val) => {
      this.unidades = val['body'].map(cat => ({ text: cat.detalle, value: cat.id }));
      this.unidadesText = val['body'].map(cat => cat.detalle);
    }, () => notify({ message: "Ha ocurrido un error al consultar las unidades"}, "error"));
  }  
  GetAllArticul() {
    this.articuloService.GetAll().pipe(
      retry(1)).subscribe((val) => {
      this.articulos = val['body'];   
      console.log(this.articulos);
      this.loadingVisible = false;
    }, () => notify({ message: "Ha ocurrido un error al consultar los articulos"}, "error"));
  }  
  GetAllArticulo(){
    this.articuloService.GetAll()
    .subscribe((data: Existencia[]) => {
      console.log(data['data']);
      this.articulos = data['data'];
      this.loadingVisible = false;
    }, () => notify({ message: "Ha ocurrido un error al consultar los articulos"}, "error"))
  }

    onRowInserted(event) {
    const index = this.articulos.findIndex(articulo => !articulo.id);
    const articulo: Existencia = event.data;
    console.log(this.unidades);
    articulo.articulo.unidadId = this.unidades.find(cat => cat.text === event.data.articulo.unidadDetalle).value;
    
    this.articuloService.Create(articulo)
      .subscribe((data: Existencia) => {
        this.articulos[index] = data;
        this.dataGrid.instance.refresh();
        console.log(data);
        notify({ message: data ? "Articulo creado exitosamente"
        : "Error al registrar el articulo" , width: 400 },data ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"));
  }

  onRowUpdated(event) {
    const articulo: Existencia = event.data;
    console.log(event.data);
    console.log(this.unidades);
    articulo.articulo.unidadId = this.unidades.find(cat => cat.text === event.data.articulo.unidadDetalle).value;
    this.articuloService.Update(articulo)
      .subscribe((data: Existencia) => {
        notify({ message: data ? "Articulo actualizado exitosamente"
        : "Error al registrar el articulo", width: 400 },data ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"))
  }
}
