import { Injectable } from '@angular/core';
import { ComponentPortal } from '@angular/cdk/portal';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { MatSpinner } from '@angular/material';

@Injectable({ providedIn: 'root'})

export class ProgressSpinnerService {
    private progressSpinnerRef: OverlayRef = this.create();

    constructor(private overlay: Overlay) { }

    private create() {
        return this.overlay.create({
            positionStrategy: this.overlay.position().global().centerHorizontally().centerVertically(),
            hasBackdrop: true
        });
    }

    start() {
        this.progressSpinnerRef.attach(new ComponentPortal(MatSpinner))
    }

    stop() {
        this.progressSpinnerRef.detach();
    }
}
