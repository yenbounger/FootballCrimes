import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { BehaviorSubject, Observable } from "rxjs";
import { CrimeData, TableData } from "./table.model";
import { TableService } from "./table.service";

export class TableDataSource implements DataSource<CrimeData> {
  private dataSubject$ = new BehaviorSubject<CrimeData[]>([]);
  private totalCount$ = new BehaviorSubject<number>(0);

  constructor(private tableService: TableService) {}

  loadData(pageIndex = 0, pageSize = 10, direction = 'asc'){
    this.tableService.getTableData(pageIndex,pageSize, direction).subscribe(data => {
      console.log(data);
      this.dataSubject$.next(data.crimeData)
      this.totalCount$.next(data.count);
    });
  }
  connect(collectionViewer: CollectionViewer): Observable<readonly CrimeData[]> {
    return this.dataSubject$.asObservable();
  }
  disconnect(collectionViewer: CollectionViewer): void {
    this.dataSubject$.complete();
  }

  get totalCount(): Observable<number> {
    return this.totalCount$.asObservable();
  }

}
