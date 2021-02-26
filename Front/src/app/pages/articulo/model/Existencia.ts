import { Articulo } from "./Articulo";

export class Existencia
{
    id: number;
    existenciaMinima: number;
    existenciaMaxima: number;
    cantDisponible: number;
    articulo: Articulo;
}