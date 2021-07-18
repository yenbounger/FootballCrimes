import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { TableData } from './table.model';
@Injectable({
  providedIn: 'root'
})
export class TableService {

  constructor(private http: HttpClient) { }


  getTableData(pageIndex = 0, pageSize = 10, sortDirection = 'asc') {
    return this.http.get<TableData>(`${environment.apiUrl}/footballcrimes`, {
      params: new HttpParams().set('take', pageSize).set('page', pageIndex).set('sortDirection', sortDirection)
    })
  }

}
