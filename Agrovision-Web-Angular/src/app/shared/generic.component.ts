import { OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Entity } from '../models/entity';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

export class GenericComponent<T> implements OnInit {
    entities: Entity[];
    currentEntity: Entity = new Entity();
    newEntity: Entity = new Entity();

    constructor(
        private entityType: String,
        private dataService: DataService<Entity>,
        private snackBar: MatSnackBar) {
        this.dataService.entityType = entityType;
    }

    ngOnInit() {
        this.loadData();
    }

    add() {
        this.dataService.progressSpinner.start();

        this.dataService.add(this.newEntity).then((result) => {
        this.snackBar.open(this.entityType + ' added', '', {duration: 1000});
        this.dataService.progressSpinner.stop();

        this.newEntity = new Entity();
        this.loadData();
      });
    }

    update(entity: Entity) {
      this.dataService.progressSpinner.start();

      this.dataService.update(entity).then((result) => {
        this.snackBar.open(this.entityType + ' updated', '', {duration: 1000});
        this.dataService.progressSpinner.stop();

        this.loadData();
      });
    }

    delete(entity: Entity) {
        this.dataService.progressSpinner.start();

        this.dataService.delete(entity.id).then((result) => {
            this.snackBar.open(this.entityType + ' deleted', '', { duration: 1000 });
            this.dataService.progressSpinner.stop();

            this.loadData();
        });
    }

    cancel() {
        this.loadData();
    }

    loadData() {
        this.dataService.progressSpinner.start();

        this.dataService.getList().then((result) => {
            this.entities = result;
            this.dataService.progressSpinner.stop();
        });
    }
}
