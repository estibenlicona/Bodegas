import { Injectable } from '@angular/core';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }

  sweetAlert(icono: SweetAlertIcon, message: string){
    Swal.fire({
      position: 'center',
      icon: icono,
      title: message,
      showConfirmButton: true
    });
  }
}
