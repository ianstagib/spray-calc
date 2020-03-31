import { Component, OnInit } from '@angular/core';
import {Sprayer} from '../../models/sprayer';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-sprayers',
  templateUrl: './sprayers.component.html',
  styleUrls: ['./sprayers.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class SprayersComponent implements OnInit {
  displayColumns: String[] = ['name', 'ratemin', 'ratemax', 'options'];

  sprayers: Sprayer[];
  currentSprayer: Sprayer = new Sprayer();
  newSprayer: Sprayer = new Sprayer();

  constructor(private http: HttpClient) {

  }

  ngOnInit() {
    this.loadData();
  }

  add(sprayer: Sprayer) {
    return this.http.post(environment.api + '/sprayer', sprayer).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  update(sprayer: Sprayer) {
    return this.http.put(environment.api + '/sprayer', sprayer).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  delete(id: bigint) {
    return this.http.delete(environment.api + '/sprayer/' + id).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  cancel() {
    this.loadData();
  }

  loadData() {
    return this.http.get<Sprayer[]>(environment.api + '/sprayer').toPromise().then((result) => {
      this.sprayers = result;
    });
  }
}
