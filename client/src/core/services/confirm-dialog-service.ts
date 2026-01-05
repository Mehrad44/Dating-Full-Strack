import { Injectable } from '@angular/core';
import { ConfiromDialog } from '../../shared/confirom-dialog/confirom-dialog';

@Injectable({
  providedIn: 'root',
})
export class ConfirmDialogService {
  private dialogComponent? : ConfiromDialog;

  register(component: ConfiromDialog){
    this.dialogComponent = component;
  }

  confirm(message = 'Are you Sure?'): Promise<boolean>{
    if(!this.dialogComponent){
      throw new Error('Cofirm dialog component ins not registred');
    }
    return this.dialogComponent.open(message);
  }
}
