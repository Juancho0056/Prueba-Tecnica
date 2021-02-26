export interface Cliente
{
    id: number,
    tipoDocumentoId: number,
    nroDocumento: string,
    primerNombre: string,
    segundoNombre: string,
    fechaNacimiento: Date,
    tipoDocumentoDetalle: string,
    nombreCliente: string
}