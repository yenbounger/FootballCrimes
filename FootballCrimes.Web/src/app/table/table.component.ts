import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge, Observable, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { TableService } from './table.service';
import { TableDataSource } from './TableDataSource.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit, AfterViewInit, OnDestroy {
  dataSource: TableDataSource;
  totalCount: Observable<number>;
  displayedColumns = ["teamName", "stadiumName", "crimeType", "dateCommited"];
  subs = new Subscription();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(private tableService: TableService) {
    this.dataSource = new TableDataSource(this.tableService);
    this.totalCount = this.dataSource.totalCount;
  }

  ngOnInit(): void {
    this.dataSource.loadData();
  }

  ngAfterViewInit() {
    this.subs.add(this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0));
    this.subs.add(merge(this.paginator.page, this.sort.sortChange).subscribe(event => {
      this.loadData();
    }));
  }

  private loadData() {
    this.dataSource.loadData(this.paginator.pageIndex, this.paginator.pageSize, this.sort.direction);
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

}
