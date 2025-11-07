import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ArticuloService } from '../../services/articulos/aticulo.service';
import { ArticuloInterface } from '../../interfaces/articulos.interface';

import { Router } from '@angular/router';
import  Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

declare var bootstrap: any;

@Component({
  selector: 'app-articulos',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './articulos.component.html',
  styleUrl: './articulos.component.scss',
})

export class ArticulosComponent implements OnInit  {
  articuloList: ArticuloInterface[] = [];
    articuloFormComponent: FormGroup;
    isDisabled: boolean = true;
    showField: boolean = true;
  
  
     @ViewChild('ArticuloModal') ArticuloModal!: ElementRef;
     modalInstance: any;
  
    constructor(private articuloService: ArticuloService, private router: Router, private fb: FormBuilder)
    { 
      this.articuloFormComponent = this.fb.group({
        id:[''],
        codigo: ['', Validators.required],
        descripcion: [''],
        precio: [''],
        stock: ['']
      });
    }
  
    ngOnInit(): void {
      this.getArticulos();
    }
  
    getArticulos(){
      this.articuloService.getArticulos().subscribe({
        next: (result) => {
          this.articuloList = result;
        },
        error:(err) => {
          console.log(err);
        }
      })    
    }  
  
    openEditModal(Articulo: any) {
      this.showField = true;
      this.articuloFormComponent.patchValue({
        id: Articulo.id,
        codigo: Articulo.codigo,
        descripcion: Articulo.descripcion,
        precio: Articulo.precio,
        stock: Articulo.stock,
      });
  
      this.modalInstance.show();
    }
  
    onSubmit() {
      if (this.articuloFormComponent.valid) {
        const Articulo = this.articuloFormComponent.value;
        console.log(Articulo);
        if(Articulo.id)
        {
          this.articuloService.updateArticulo(Articulo.id, Articulo).subscribe({
            next: (res) => {
              Swal.fire({
                title: 'Actualizado',
                text: 'Articulo actualizado correctamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
              });
              this.articuloFormComponent.reset();
              this.closeModal();
              this.getArticulos(); // refrescar lista
            },
            error: (err) => {
              Swal.fire({
                title: 'Error',
                text: 'No se pudo actualizar el Articulo.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
              });
            }
          });
        }
        else
        {
          this.articuloService.addArticulo(this.articuloFormComponent.value).subscribe({
          next: (res) => {
            Swal.fire({
              title: 'Creado',
              text: 'Registro guardado correctamente.',
              icon: 'success',
              confirmButtonText: 'Aceptar'
            });
            this.articuloFormComponent.reset();
            this.closeModal();
            this.getArticulos();
          },
            error: (err) => {
              console.log(err);
              Swal.fire({
                title: 'Error',
                text: 'No se pudo crear el Articulo.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
              });
            }
          });
        }
      }
    }
  
    deleteArticulo(id: number | string) {
    Swal.fire({
      title: '¿Estás seguro que desea eliminar la Articulo?',
      text: 'Esta acción no se puede deshacer',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.articuloService.deleteArticulo(id).subscribe({
          next: () => {
            Swal.fire('Eliminado', 'El Articulo fue eliminado correctamente.', 'success');
            this.getArticulos();
          },
          error: (err) => {
            Swal.fire('Error', 'No se pudo eliminar el Articuloo.', 'error');
            console.error(err);
          }
        });
      }
    });
  }
  
  
    ngAfterViewInit() {
      this.modalInstance = new bootstrap.Modal(this.ArticuloModal.nativeElement);
    }
  
    openModal() {
      this.showField = false;
      this.articuloFormComponent.reset();
      this.modalInstance.show();
    }
  
    closeModal() {
      this.modalInstance.hide();
    }
}

