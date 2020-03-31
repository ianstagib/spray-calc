import { Component, OnInit } from '@angular/core';
import {Field} from '../../models/field';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-fields',
  templateUrl: './fields.component.html',
  styleUrls: ['./fields.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class FieldsComponent  implements OnInit {
  displayColumns: String[] = ['name', 'size', 'options'];

  fields: Field[];
  currentField: Field = new Field();
  newField: Field = new Field();

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.loadData();
    this.newField = new Field();
  }

  add(field: Field) {
    return this.http.post(environment.api + '/field', field).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  update(field: Field) {
    return this.http.put(environment.api + '/field', field).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  delete(id: bigint) {
    return this.http.delete(environment.api + '/field/' + id).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  cancel() {
    this.ngOnInit();
  }

  loadData() {
    return this.http.get<Field[]>(environment.api + '/field').toPromise().then((result) => {
      this.fields = result;
    });
  }
}

