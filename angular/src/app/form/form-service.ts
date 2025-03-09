import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';



@Injectable({
    providedIn: 'root'
  })
  export class FormService {
    
    resetFormGroup(formGroup: FormGroup): FormGroup{
        formGroup.reset();
        Object.keys(formGroup.controls).forEach(key => {
            formGroup.controls[key].clearValidators();
            formGroup.controls[key].updateValueAndValidity();
        });
        return formGroup;
    }
  }