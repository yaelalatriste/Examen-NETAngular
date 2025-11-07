import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ClienteService } from '../../services/clientes/cliente.service';
import { ClienteInterface } from '../../interfaces/clientes.interface';
import { Router } from '@angular/router';
import  Swal from 'sweetalert2';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

declare var bootstrap: any;

@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './cliente.component.html',
  styleUrl: './cliente.component.scss'
})

export class ClienteComponent implements OnInit {
  clienteList: ClienteInterface[] = [];
  clienteFormComponent: FormGroup;
  isDisabled: boolean = true;
  showField: boolean = true;


   @ViewChild('ClienteModal') ClienteModal!: ElementRef;
   modalInstance: any;

  constructor(private clienteService: ClienteService, private router: Router, private fb: FormBuilder)
  { 
    this.clienteFormComponent = this.fb.group({
      id:[''],
      nombre: ['', Validators.required],
      apellidos: ['', [Validators.required, Validators.min(0)]],
      direccion: ['']
    });
  }

  ngOnInit(): void {
    this.getClientes();
  }

  getClientes(){
    this.clienteService.getClientes().subscribe({
      next: (result) => {
        this.clienteList = result;
      },
      error:(err) => {
        console.log(err);
      }
    })    
  }  

  openEditModal(Cliente: any) {
    this.showField = true;
    this.clienteFormComponent.patchValue({
      id: Cliente.id,
      nombre: Cliente.nombre,
      apellidos: Cliente.apellidos,
      direccion: Cliente.direccion,
    });

    this.modalInstance.show();
  }

  onSubmit() {
    if (this.clienteFormComponent.valid) {
      const Cliente = this.clienteFormComponent.value;
      console.log(Cliente);
      if(Cliente.id)
      {
        this.clienteService.updateCliente(Cliente.id, Cliente).subscribe({
          next: (res) => {
            Swal.fire({
              title: 'Actualizado',
              text: 'Cliente actualizado correctamente.',
              icon: 'success',
              confirmButtonText: 'Aceptar'
            });
            this.clienteFormComponent.reset();
            this.closeModal();
            this.getClientes(); // refrescar lista
          },
          error: (err) => {
            Swal.fire({
              title: 'Error',
              text: 'No se pudo actualizar el Cliente.',
              icon: 'error',
              confirmButtonText: 'Aceptar'
            });
          }
        });
      }
      else
      {
        this.clienteService.addCliente(this.clienteFormComponent.value).subscribe({
        next: (res) => {
          Swal.fire({
            title: 'Creado',
            text: 'Registro guardado correctamente.',
            icon: 'success',
            confirmButtonText: 'Aceptar'
          });
          this.clienteFormComponent.reset();
          this.closeModal();
          this.getClientes();
        },
          error: (err) => {
            console.log(err);
            Swal.fire({
              title: 'Error',
              text: 'No se pudo crear el Cliente.',
              icon: 'error',
              confirmButtonText: 'Aceptar'
            });
          }
        });
      }
    }
  }

  deleteCliente(id: number | string) {
  Swal.fire({
    title: '¿Estás seguro que desea eliminar el Clienteo?',
    text: 'Esta acción no se puede deshacer',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Sí, eliminar',
    cancelButtonText: 'Cancelar'
  }).then((result) => {
    if (result.isConfirmed) {
      this.clienteService.deleteCliente(id).subscribe({
        next: () => {
          Swal.fire('Eliminado', 'El Clienteo fue eliminado correctamente.', 'success');
          this.getClientes();
        },
        error: (err) => {
          Swal.fire('Error', 'No se pudo eliminar el Clienteo.', 'error');
          console.error(err);
        }
      });
    }
  });
}


  ngAfterViewInit() {
    this.modalInstance = new bootstrap.Modal(this.ClienteModal.nativeElement);
  }

  openModal() {
    this.showField = false;
    this.clienteFormComponent.reset();
    this.modalInstance.show();
  }

  closeModal() {
    this.modalInstance.hide();
  }
}