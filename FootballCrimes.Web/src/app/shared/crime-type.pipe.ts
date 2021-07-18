import { Pipe, PipeTransform } from '@angular/core';
import { CrimeType } from './crime-type.enum';

@Pipe({
  name: 'crimeType'
})
export class CrimeTypePipe implements PipeTransform {

  transform(value: CrimeType, ...args: unknown[]): string {
    switch (value) {
      case CrimeType.AntiSocialBehaviour:
        return "Anti-social Behaviour";
      case CrimeType.BicycleTheft:
        return "Bicycle Theft";
      case CrimeType.Burglary:
        return "Burglary";
      case CrimeType.CriminalDamageAndArson:
        return "Criminal Damage and Arson";
      case CrimeType.Drugs:
        return "Drugs";
      case CrimeType.OtherCrime:
        return "Other Crime";
      case CrimeType.OtherTheft:
        return "Other Theft";
      case CrimeType.PossessionofWeapons:
        return "Possession of Weapons";
      case CrimeType.PublicOrder:
        return "Public Order";
      case CrimeType.Robbery:
        return "Robbery";
      case CrimeType.Shoplifting:
        return "Shoplifting";
      case CrimeType.TheftFromThePerson:
        return "Theft From The Person";
      case CrimeType.VehicleCrime:
        return "Vehicle Crime";
      case CrimeType.ViolenceAndSexualOffences:
        return "Violence and Sexual Offences";
      default:
        throw new Error(`${value} missing from mapping`)
        break;
    }
  }

}
