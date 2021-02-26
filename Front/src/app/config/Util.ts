import { format } from 'util';

export class Util {

    GetFormattedDate(fecha: Date) {
        console.log("mes: "+fecha.getMonth()+1);
        var month = format(fecha.getMonth()+1);//format();
        var day = format(fecha.getDate());
        var year = format(fecha.getFullYear());
        return year + "-" + month + "-" + day;
    }
    GetFormattedDateString(vfecha: string) {
        const fecha = new Date(vfecha);
        var month = format(fecha.getMonth()+1);//format();
        var day = format(fecha.getDate());
        var year = format(fecha.getFullYear());
        return year + "-" + month + "-" + day;
    }
}