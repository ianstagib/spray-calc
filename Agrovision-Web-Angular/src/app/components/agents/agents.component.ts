import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Agent } from '../../models/agent';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {environment} from '../../../environments/environment';

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

export class AgentsComponent implements OnInit {
  displayColumns: String[] = ['name', 'RecommendedDosage', 'options'];

  agents: Agent[];
  currentAgent: Agent = new Agent();
  newAgent: Agent = new Agent();

  constructor(private http: HttpClient) {    }

  ngOnInit() {
    this.loadData();
  }

  add(agent: Agent) {
    return this.http.post(environment.api + '/agent', agent).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  update(agent: Agent) {
    return this.http.put(environment.api + '/agent', agent).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  delete(id: bigint) {
    return this.http.delete(environment.api + '/agent/' + id).toPromise().then(() => {
      this.ngOnInit();
    });
  }

  cancel() {
    this.loadData();
  }

  loadData() {
    return this.http.get<Agent[]>(environment.api + '/agent').toPromise().then((result) => {
      this.agents = result;
    });
  }
}
