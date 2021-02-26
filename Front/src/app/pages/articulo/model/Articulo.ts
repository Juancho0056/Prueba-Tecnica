import {IArticulo} from './IArticulo';
export class Articulo implements IArticulo
{
    id: number;
    detalle: number;
    unidadId: number;
    unidadDetalle: string;
    precio: number;
    
    constructor(data?)
    {
        
        data = data || {};
        this.id = data.articulo.id || 0;
        this.detalle = data.articulo.detalle || '';
        this.unidadId = data.articulo.unidadId || '';
        this.unidadDetalle = data.articulo.unidadDetalle || '';
        this.precio = data.articulo.precio || 0;
    }
}