import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Buyer } from 'src/app/models/buyer';

@Component({
  selector: 'app-buyers-form',
  templateUrl: './buyers-form.component.html',
  styleUrls: ['./buyers-form.component.css']
})
export class BuyersFormComponent {
  buyerForm: FormGroup;

  constructor(
    private dialogRef: MatDialogRef<BuyersFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Buyer,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    
  }
  
  close(){
    this.dialogRef.close();
  }

  onSubmit(){
  }
}
