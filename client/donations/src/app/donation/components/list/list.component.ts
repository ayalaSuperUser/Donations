import { Component, OnInit, ViewChild } from '@angular/core';
import {MatAccordion} from '@angular/material/expansion';
import { first } from 'rxjs';
import { Donation } from '../../models/donation';
import { DonationsService } from '../../services/donations.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  donations!: Donation[];

    constructor(private userService: DonationsService) {}

    ngOnInit() {
        this.userService.getAll()
            .pipe(first())
            .subscribe(don => this.donations = don);
    }

    delete(id: number) {
        const donation = this.donations.find(x => x.id === id);
        if (!donation) return;
        donation.isDeleting = true;
        this.userService.delete(id)
            .pipe(first())
            .subscribe(() => this.donations = this.donations.filter(x => x.id !== id));
    }


}
