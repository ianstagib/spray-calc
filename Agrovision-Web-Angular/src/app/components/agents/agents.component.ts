import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { Agent } from '../../models/agent';
import { GenericComponent } from '../../shared/generic.component';
import { MatSnackBar } from '@angular/material';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-agents',
  templateUrl: './agents.component.html',
  styleUrls: ['./agents.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class AgentsComponent extends GenericComponent<Agent> implements OnInit {
  displayColumns: String[] = ['name', 'RecommendedDosage', 'options'];

  constructor(
    dataService: DataService<Agent>,
    snackBar: MatSnackBar) {
      super('Agent', dataService, snackBar);
    }
}
