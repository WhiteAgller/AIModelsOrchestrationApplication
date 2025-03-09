import { Injectable } from '@angular/core';
import { AsyncValidatorFn, FormControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Observable, of } from 'rxjs';


@Injectable({
    providedIn: 'root'
  })
  export class ValidatorsService {
    
    public uniqueNameValidator(items: any[], property: string): AsyncValidatorFn {
      return (control: FormControl): Observable<ValidationErrors | null> => {
        if(control.value == null){
          return of(null)
        }
        const value = control.value.toLowerCase();
        const duplicate = items.some(item => item[property].toLowerCase() === value); 
        return duplicate ? of({ uniqueName: true }) : of(null); 
      };
    }
  }