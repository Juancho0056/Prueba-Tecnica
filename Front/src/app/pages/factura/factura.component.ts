import { Component, OnInit, NgModule, enableProdMode, ViewChild, AfterViewInit } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';
import {Factura} from './model/Factura';
import {Detalle} from './model/Detalle';
import {Item} from '../../config/Item';
import {FacturaService} from './service/factura.service';
import {ClienteService} from '../cliente/service/cliente.service';
import {Cliente} from '../cliente/model/Cliente';
import { retry } from 'rxjs/operators';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.scss']
})
export class FacturaComponent implements OnInit, AfterViewInit {

  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;
  showHeaderFilter: boolean = true;
  showFilterRow: boolean = true;
  allMode: string;
  checkBoxesMode: string;
  loadingVisible = true;
  facturas:  Factura[] = [];
  clientes:  Item[] = [];
  clientesText: string[] = [];
  constructor(private facturaService: FacturaService, private clienteService: ClienteService) {
    this.allMode = 'allPages';
    this.checkBoxesMode = 'onClick';
    
  }
  ngAfterViewInit() {
  }
  ngOnInit() {
    this.GetAllFacturas();
    this.GetAllClientes();
  }
  onValueChanged (e) {
  }  
  GetAllClientes() {
    this.clienteService.GetAll().pipe(
      retry(1)).subscribe((val) => {
        console.log(val['body']);
      this.clientes = val['body'].map(cat => ({ text: cat.nombreCliente, value: cat.id }));
      this.clientesText = val['body'].map(cat => cat.nombreCliente);
    }, () => notify({ message: "Ha ocurrido un error al consultar las clientes"}, "error"));
  }  
  GetAllFacturas(){
    this.facturaService.GetAll()
    .subscribe((data: Factura[]) => {
      console.log(data['body']);
      this.facturas = data['body'];
      this.loadingVisible = false;
    }, () => notify({ message: "Ha ocurrido un error al consultar las facturas"}, "error"))
  }

    onRowInserted(event) {
    const index = this.facturas.findIndex(factura => !factura.id);
    const factura: Factura = event.data;
    factura.clienteId = this.clientes.find(cat => cat.text === event.data.nroDocumento+"-"+event.data.primerNombre).value;
    this.facturaService.Create(factura)
      .subscribe((data: Factura) => {
        this.facturas[index] = data;
        this.dataGrid.instance.refresh();
        notify({ message: data ? "Factura creada exitosamente"
        : "Error al registrar el factura" , width: 400 },data ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"));
  }

}

