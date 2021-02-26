import { Component, OnInit, NgModule, enableProdMode, ViewChild, AfterViewInit } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';
import {Cliente} from './model/Cliente';
import {Item} from '../../config/Item';
import {ClienteService} from './service/cliente.service';
import {TipoDocumentoService} from './service/tipodocumento.service';
import { retry } from 'rxjs/operators';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit, AfterViewInit {

  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;
  showHeaderFilter: boolean = true;
  showFilterRow: boolean = true;
  allMode: string;
  checkBoxesMode: string;
  loadingVisible = true;
  clientes:  Cliente[] = [];
  tipos:  Item[] = [];
  tiposText: string[] = [];
  constructor(private clienteService: ClienteService, private tipoDocumentoService : TipoDocumentoService) {
    this.allMode = 'allPages';
    this.checkBoxesMode = 'onClick';
    
  }
  ngAfterViewInit() {
  }
  ngOnInit() {
    this.GetAllClientes();
    this.GetAllTipoDocumentos();
  }
  onValueChanged (e) {
  }

  GetAllTipoDocumentos() {
    this.tipoDocumentoService.GetAll().pipe(
      retry(1)).subscribe((val) => {
        console.log(val['body']);
      this.tipos = val['body'].map(cat => ({ text: cat.detalle, value: cat.id }));
      this.tiposText = val['body'].map(cat => cat.detalle);
    }, () => notify({ message: "Ha ocurrido un error al consultar los tipos de documentos"}, "error"));
  }  
  GetAllClient() {
    this.clienteService.GetAll().pipe(
      retry(1)).subscribe((val) => {
      this.clientes = val['body'];
      this.loadingVisible = false;
    }, () => notify({ message: "Ha ocurrido un error al consultar los clientes"}, "error"));
  }  
  GetAllClientes(){
    this.clienteService.GetAll()
    .subscribe((data: Cliente[]) => {
      console.log(data['body']);
      this.clientes = data['body'];
      this.loadingVisible = false;
    }, () => notify({ message: "Ha ocurrido un error al consultar los clientes"}, "error"))
  }

    onRowInserted(event) {
    const index = this.clientes.findIndex(cliente => !cliente.id);
    const cliente: Cliente = event.data;
    cliente.tipoDocumentoId = this.tipos.find(cat => cat.text === event.data.tipoDocumentoDetalle).value;
    
    this.clienteService.Create(cliente)
      .subscribe((data: Cliente) => {
        this.clientes[index] = data;
        this.dataGrid.instance.refresh();
        notify({ message: data ? "Cliente creado exitosamente"
        : "Error al registrar el cliente" , width: 400 },data ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"));
  }

  onRowUpdated(event) {
    const cliente: Cliente = event.data;
    cliente.tipoDocumentoId = this.tipos.find(cat => cat.text === event.data.tipoDocumentoDetalle).value;
    this.clienteService.Update(cliente)
      .subscribe((data: Cliente) => {
        notify({ message: data ? "Cliente actualizado exitosamente"
        : "Error al registrar el cliente", width: 400 },data ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"))
  }
}

