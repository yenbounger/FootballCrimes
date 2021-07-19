import { Component, Input, OnInit } from '@angular/core';
import { CrimeTypePipe } from 'src/app/shared/crime-type.pipe';
import { Team } from '../team.model';
import { CrimeTypeCount } from './crime-type-count.model';

@Component({
  selector: 'app-crimes-by-type',
  templateUrl: './crimes-by-type.component.html',
  styleUrls: ['./crimes-by-type.component.scss']
})
export class CrimesByTypeComponent implements OnInit {
  @Input() team!: Team;
  @Input() cardBody!: HTMLElement;
  data: CrimeTypeCount[] = [];
  constructor(public crimeTypePipe: CrimeTypePipe) { }

  ngOnInit(): void {
    this.team.teamCrimes.forEach(crime => {
      var existingData = this.data.find(x => x.name == crime.crimeType);
      if (existingData) {
        existingData.value++;
      } else {
        this.data.push({ value: 1, name: crime.crimeType });
      }
    });
  }


  get sortedData() {
    return this.data.sort((a, b) => a.value - b.value );
  }
}
