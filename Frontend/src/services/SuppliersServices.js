import api from "@/plugins/api";

async function getSuppliers(page, pageSize) {
  try {
    const params = new URLSearchParams({ page, pageSize });
    const response = await api.get("/suppliers", { params });
    return response.data;
  } catch (error) {
    console.error(error);
  }
}

async function getSupplier(id) {
  try {
    const response = await api.get(`/suppliers/${id}`);
    return response.data;
  } catch (error) {
    console.error(error);
  }
}

async function createSupplier(supplier) {
  try {
    const response = await api.post("/suppliers", supplier);
    return response.data;
  } catch (error) {
    console.error(error);
  }
}

async function updateSupplier(supplier) {
  try {
    const response = await api.put(`/suppliers/${supplier.id}`, supplier);
    return response.data;
  } catch (error) {
    console.error(error);
  }
}

async function deleteSupplier(supplier) {
  try {
    const response = await api.delete(`/suppliers/${supplier.id}`, {
      data: supplier,
    });
    return response.data;
  } catch (error) {
    console.error(error);
  }
}

async function searchSuppliers(query, page, pageSize, cancellationToken) {
  try {
    const params = new URLSearchParams({ query, page, pageSize });
    const response = await api.get("/suppliers/search", { params }, { cancelToken: cancellationToken });

    return response.data;
  } catch (error) {
    console.error(error);
  }
}

export {
  getSuppliers,
  getSupplier,
  createSupplier,
  updateSupplier,
  deleteSupplier,
  searchSuppliers
};
