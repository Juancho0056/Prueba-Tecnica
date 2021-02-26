import {Detalle} from './Detalle';
export interface Factura
{
    id: number,
    clienteId: number,
    nombreCliente: string,
    fechaVenta: Date,
    vlrVenta: number,
    detalles: Detalle[]
}