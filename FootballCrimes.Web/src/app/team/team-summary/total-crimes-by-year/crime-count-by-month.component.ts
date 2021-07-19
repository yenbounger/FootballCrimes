import { formatDate } from '@angular/common';
import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Team } from '../team.model';
import { CrimeCountMonth } from './crime-count-by-month.model';

@Component({
  selector: 'app-crime-count-by-month',
  templateUrl: './crime-count-by-month.component.html',
  styleUrls: ['./crime-count-by-month.component.scss']
})
export class CrimeCountByMonth implements OnInit {
  @Input() team!: Team;
  @Input() cardBody!: HTMLElement;
  data: CrimeCountMonth[] = [];

  constructor() { }

  ngOnInit(): void {
    this.team.teamCrimes.forEach(crime => {
      var existingData = this.data.find(x => x.name == crime.dateCommited);
      if (existingData) {
        existingData.value++;
      } else {
        this.data.push({ value: 1, name: crime.dateCommited });
      }
    });
  }

  formatxAxisTicks(date: Date) {
    return formatDate(date, 'MMM yyyy', 'en-gb');
  }



  get sortedData() {
    return this.data.sort((a, b) => new Date(a.name).getTime() - new Date(b.name).getTime() );
  }


}
