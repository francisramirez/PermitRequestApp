<template>
      <h1 id="tableLabel">Permits</h1>
      <p>From here you can view the list of permits</p>
      <p v-if="!permits"><em>Loading...</em></p>
     <div class="float-left p-2">
       <router-link :to="{ name: 'Create' }" class="nav-link text-dark"><button class="btn btn-outline-primary">Create</button></router-link>
     </div>
     <br/>
    <table class='table table-striped' aria-labelledby="tableLabel" v-if="permits">
        <thead>
            <tr>
                <th>Employee Name</th>
                <th>Employee Last Name</th>
                <th>Permit Type</th>
                <th>Permit Date</th>
                 <th></th>
                  <th></th>
                  
            </tr>
        </thead>
        <tbody>
            <tr v-for="permit of permits" v-bind:key="permit">
                <td>{{ permit.EmployeeName }}</td>
                <td>{{ permit.EmployeeLastName }}</td>
                <td>{{ permit.PermitTypeDescription }}</td>
                <td>{{ permit.PermitDate }}</td>
                <td>
                  <router-link :to="{ name: 'Edit',params: { id: permit.Id } }" class="nav-link text-dark"><button class="btn btn-outline-primary">Edit</button></router-link>
                </td>
                <td> <a href="#" v-on:click="Remove(permit)"><button class="btn btn-outline-danger">Remove </button></a></td>
                  
            </tr>
        </tbody>
    </table>
</template>

<script>
 
    import axios from 'axios';
    const urlBase = 'http://localhost:37803';

    export default {
        name: "PermitList",
        data() {
            return {
                permits: []
            }
        },
        created(){

        },
        methods:{
           getPermits(){
               
               axios.get(`${urlBase}/GetPermits`).then((response) => {
                        
                        let result = response.data;

                         if(result.Success){
                            this.permits = result.Data;
                         }
                         else{
                            alert(result.Message);
                         }
                        
                    }).catch(function(error){
                       
                       console.log(error);
               });
           },
           Remove(permit){
          
          let empName = permit.EmployeeName + ' ' + permit.EmployeeLastName;

             if( confirm(`Do you want to remove this employee: ${ empName } ?`)){

                      const params ={
                          Id: permit.Id
                      };
                     
                   axios.post(`${urlBase}/RemovePermit/`,params).then((response) => {
                        
                       let result = response.data;

                       if (result.Success) {
                          
                          alert(result.Message);
                          
                          this.getPermits();
                       }
                    }).catch(function(error){
                         console.log(error);
                     });
              
            }
           
           }
        }, 
        mounted() {
             this.getPermits();
        }
    }
</script>

<style scoped>

</style>