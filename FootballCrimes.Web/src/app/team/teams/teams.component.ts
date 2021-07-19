import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { TeamsService } from './teams.service';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss']
})
export class TeamsComponent implements OnInit {
  cols: number = 10;
  rowHeight = "40rem"
  cardData$ = this.teamsservice.getTeamsData();

  columnsPerBreakpoint = {
    xl: 6,
    lg: 4,
    md: 3,
    sm: 2,
    xs: 1
  }

  constructor(private breakpointOberserver: BreakpointObserver, private teamsservice: TeamsService) { }

  ngOnInit(): void {
    this.breakpointOberserver.observe([Breakpoints.XLarge, Breakpoints.Large, Breakpoints.Medium, Breakpoints.Small, Breakpoints.XSmall]).subscribe(state => {
      if (state.matches) {
        if (state.breakpoints[Breakpoints.XSmall]) {
          this.cols = this.columnsPerBreakpoint.xs;
          this.rowHeight = "20rem"
        }
        if (state.breakpoints[Breakpoints.Small]) {
          this.cols = this.columnsPerBreakpoint.sm;
          this.rowHeight = "20rem"
        }
        if (state.breakpoints[Breakpoints.Medium]) {
          this.cols = this.columnsPerBreakpoint.md;
          this.rowHeight = "20rem"
        }
        if (state.breakpoints[Breakpoints.Large]) {
          this.cols = this.columnsPerBreakpoint.lg;
          this.rowHeight = "40rem";
        }
        if (state.breakpoints[Breakpoints.XLarge]) {
          this.cols = this.columnsPerBreakpoint.xl;
          this.rowHeight = "27rem";
        }
      }
    });
  }

}
