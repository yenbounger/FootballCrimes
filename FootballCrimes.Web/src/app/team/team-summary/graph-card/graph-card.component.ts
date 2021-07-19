import { Component, Input, OnInit } from '@angular/core';
import { Team } from '../team.model';

@Component({
  selector: 'app-graph-card',
  templateUrl: './graph-card.component.html',
  styleUrls: ['./graph-card.component.scss']
})
export class GraphCardComponent implements OnInit {
  @Input() team!: Team;
  selectedIndex = 0;

  constructor() { }

  ngOnInit(): void {
  }

}
