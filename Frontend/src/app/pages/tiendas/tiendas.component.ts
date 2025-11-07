import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { TiendaService } from '../../services/tiendas/tienda.service';
import { TiendaInterface } from '../../interfaces/tiendas.interface';
import { Router } from '@angular/router';
import  Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

declare var bootstrap: any;

@Component({
  selector: 'app-tiendas',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './tiendas.component.html',
  styleUrl: './tiendas.component.scss',
})
export class TiendasComponent implements OnInit  {
  tiendaList: TiendaInterface[] = [];
    tiendaFormComponent: FormGroup;
    isDisabled: boolean = true;
    showField: boolean = true;
  
  
     @ViewChild('TiendaModal') TiendaModal!: ElementRef;
     modalInstance: any;
  
    constructor(private tiendaService: TiendaService, private router: Router, private fb: FormBuilder)
    { 
      this.tiendaFormComponent = this.fb.group({
        id:[''],
        sucursal: ['', Validators.required],
        direccion: ['']
      });
    }
  
    ngOnInit(): void {
      this.getTiendas();
    }
  
    getTiendas(){
      this.tiendaService.getTiendas().subscribe({
        next: (result) => {
          this.tiendaList = result;
        },
        error:(err) => {
          console.log(err);
        }
      })    
    }  
  
    openEditModal(Tienda: any) {
      this.showField = true;
      this.tiendaFormComponent.patchValue({
        id: Tienda.id,
        sucursal: Tienda.sucursal,
        direccion: Tienda.direccion,
      });
  
      this.modalInstance.show();
    }
  
    onSubmit() {
      if (this.tiendaFormComponent.valid) {
        const Tienda = this.tiendaFormComponent.value;
        console.log(Tienda);
        if(Tienda.id)
        {
          this.tiendaService.updateTienda(Tienda.id, Tienda).subscribe({
            next: (res) => {
              Swal.fire({
                title: 'Actualizado',
                text: 'Tienda actualizada correctamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
              });
              this.tiendaFormComponent.reset();
              this.closeModal();
              this.getTiendas(); // refrescar lista
            },
            error: (err) => {
              Swal.fire({
                title: 'Error',
                text: 'No se pudo actualizar el Tienda.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
              });
            }
          });
        }
        else
        {
          this.tiendaService.addTienda(this.tiendaFormComponent.value).subscribe({
          next: (res) => {
            Swal.fire({
              title: 'Creado',
              text: 'Registro guardado correctamente.',
              icon: 'success',
              confirmButtonText: 'Aceptar'
            });
            this.tiendaFormComponent.reset();
            this.closeModal();
            this.getTiendas();
          },
            error: (err) => {
              console.log(err);
              Swal.fire({
                title: 'Error',
                text: 'No se pudo crear el Tienda.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
              });
            }
          });
        }
      }
    }
  
    deleteTienda(id: number | string) {
    Swal.fire({
      title: '¿Estás seguro que desea eliminar la Tienda?',
      text: 'Esta acción no se puede deshacer',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.tiendaService.deleteTienda(id).subscribe({
          next: () => {
            Swal.fire('Eliminado', 'El Tienda fue eliminado correctamente.', 'success');
            this.getTiendas();
          },
          error: (err) => {
            Swal.fire('Error', 'No se pudo eliminar el Tiendao.', 'error');
            console.error(err);
          }
        });
      }
    });
  }
  
  
    ngAfterViewInit() {
      this.modalInstance = new bootstrap.Modal(this.TiendaModal.nativeElement);
    }
  
    openModal() {
      this.showField = false;
      this.tiendaFormComponent.reset();
      this.modalInstance.show();
    }
  
    closeModal() {
      this.modalInstance.hide();
    }
}
