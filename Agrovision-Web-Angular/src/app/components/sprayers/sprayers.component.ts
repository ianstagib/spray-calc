import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { GenericComponent } from '../../shared/generic.component';
import { MatSnackBar, MatDialog } from '@angular/material';
import {Sprayer} from '../../models/sprayer';
import {animate, state, style, transition, trigger} from '@angular/animations';

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

export class SprayersComponent extends GenericComponent<Sprayer> implements OnInit {
  displayColumns: String[] = ['name', 'ratemin', 'ratemax', 'options'];

  constructor(
    dataService: DataService<Sprayer>,
    snackBar: MatSnackBar) {
    super('Sprayer', dataService, snackBar);
  }
}
