import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProgressSpinnerService } from './progress-spinner.service';

@Injectable({
  providedIn: 'root'
})
export class DataService<T> {
  entityType: String;

  constructor(private http: HttpClient, public progressSpinner: ProgressSpinnerService) { }

  add(entity: T) {
    return this.http.post<T>(environment.api + '/' + this.entityType, entity).toPromise();
  }

  get(id: bigint) {
    return this.http.get<T>(environment.api + '/' + this.entityType + '/' + id).toPromise();
  }

  getList() {
    return this.http.get<T[]>(environment.api + '/' + this.entityType).toPromise();
  }

  update(entity: T) {
    return this.http.put<T>(environment.api + '/' + this.entityType, entity).toPromise();
  }

  delete(id: bigint) {
    return this.http.delete<T>(environment.api + '/' + this.entityType + '/' + id).toPromise();
  }
}
