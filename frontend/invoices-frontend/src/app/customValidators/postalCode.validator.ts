import { AbstractControl, ValidatorFn } from '@angular/forms';
  
// export function postalCodeValidator(control: AbstractControl): {[key: string]: any} | null {
//     var flag = control.value.match(/^dd-ddd$/);
//     console.log(flag);
//     if (control.value.match(/^dd-ddd$/)) {
//          return { 'validate': true };
//     }
//     return null;
// }
export function postalCodeValidator(nameRe: RegExp): ValidatorFn {
    return (control: AbstractControl): {[key: string]: any} | null => {
      const forbidden = nameRe.test(control.value);
      return forbidden ? {'errors': true} : null;
    };
  }