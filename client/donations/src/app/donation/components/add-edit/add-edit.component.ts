import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import {coin} from '../../models/coin';
import { Donation } from '../../models/donation';
import{entity} from '../../models/entity-type'
import { DonationsService } from '../../services/donations.service';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.scss']
})
export class AddEditComponent implements OnInit {

  @Input() id:number;
  donationForm: FormGroup;
  isAddMode: boolean;
  loading = false;
  submitted = false;
  numRegex = /^-?\d*[.,]?\d{0,2}$/;
  alphaRegex=/^[a-zA-Z א-ת]*$/;
  coins:any;
  entities:any;
  donation:Donation;

  constructor(private donationService:DonationsService, private formBuilder: FormBuilder,private rout:ActivatedRoute,private router:Router
) {}


  ngOnInit(): void {
    this.isAddMode=this.id==null;
    this.coins=coin;
    this.entities=entity;
    this.donationForm = this.formBuilder.group({
      amount: ['', [Validators.required, Validators.pattern(this.numRegex)]],
      entityName: ['', [Validators.required, Validators.pattern(this.alphaRegex)]],
      entityType: ['', Validators.required],
      destiny: ['', Validators.required],
      coin: ['',Validators.required],
      exchangeRate: ['',[Validators.required, Validators.pattern(this.numRegex)]],
      conditions: [''],
    });

      if (!this.isAddMode) {
        this.donationService.getById(this.id)
            .pipe(first())
            .subscribe(x => {
              this.donationForm.patchValue(x)});
      }
    }

    get form(): { [key: string]: AbstractControl; }
    {
      return this.donationForm.controls;
    }

    onSubmit() {
        
        this.submitted = true;

        if (this.donationForm.invalid) {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createUser();
        } else {
            this.updateUser();
        }
    }

    createUser()
    {
      var newDonation=new Donation(Number(this.donationForm.value.amount),
        this.donationForm.value.entityName,
        this.donationForm.value.entityType,
        this.donationForm.value.destiny,
        this.donationForm.value.coin,
        Number(this.donationForm.value.exchangeRate),
        this.donationForm.value.conditions,
        )
      this.donationService.create(newDonation).pipe(first()).subscribe(()=>
      {
        console.log(this.rout);
        {this.router.navigate(['/donations'], { relativeTo: this.rout })}}).add(() => this.loading = false);
    }

    updateUser()
    {
      var updateDonation=new Donation(Number(this.donationForm.value.amount),
      this.donationForm.value.entityName,
      this.donationForm.value.entityType,
      this.donationForm.value.destiny,
      this.donationForm.value.coin,
      Number(this.donationForm.value.exchangeRate),
      this.donationForm.value.conditions,
      )
      this.donationService.update(this.id,updateDonation).pipe(first()).subscribe().add(()=>this.loading=false);
    }
}
