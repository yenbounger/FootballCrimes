import { Component, Input, OnInit } from '@angular/core';
import { TeamCard } from './team-card.model';

@Component({
  selector: 'app-team-card',
  templateUrl: './team-card.component.html',
  styleUrls: ['./team-card.component.scss']
})
export class TeamCardComponent implements OnInit {
  @Input() team!: TeamCard;

  constructor() { }

  ngOnInit(): void {
  }

}
